using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SubscriptionApp.API.Dtos.Subscriptions;
using SubscriptionApp.API.Helpers;
using SubscriptionApp.API.Infrastructure.Domain;
using SubscriptionApp.API.Models;
using SubscriptionApp.API.Models.PseudoSkus;
using SubscriptionApp.API.Models.Subscriptions;
using SubscriptionApp.API.Services.Implementations;
using SubscriptionApp.API.Services.Interfaces.SubscriptionService;
using SubscriptionApp.API.Services.Messaging.SubscriptionService;

namespace SubscriptionApp.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPseudoSkuRepository _pseudoSkuRepository;
        private readonly IMapper _mapper;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, 
        IPseudoSkuRepository pseudoSkuRepository, IMapper mapper)
        {           
            _subscriptionRepository = subscriptionRepository;
            _pseudoSkuRepository = pseudoSkuRepository;
            _mapper = mapper;
        }
        public async Task<CreateSubscriptionResponse> CreateSubscription(CreateSubscriptionRequest basketRequest)
        {
            CreateSubscriptionResponse response = new CreateSubscriptionResponse();

            Subscription subscription = new Subscription();
            

            AddPseudoSkusToSubscription(basketRequest.PseudoSkusToAdd, subscription);

            ThrowExceptionIfSubscriptionIsInvalid(subscription);

            _subscriptionRepository.Add<Subscription>(subscription);

             //When not using the EF repository, commnit using unit of work
            //_uow.Commit();

            await _subscriptionRepository.SaveAll();
           
            response.Subscription = _mapper.Map<SubscriptionView>(subscription);

            return response;
        }

        public async Task<GetSubscriptionResponse> GetSubscription(GetSubscriptionRequest subscriptionRequest)
        {
             GetSubscriptionResponse response = new GetSubscriptionResponse();

            Subscription subscription = await _subscriptionRepository.FindBy(subscriptionRequest.SubscriptionId);
            SubscriptionView subscriptionView;

            if (subscription != null)
                subscriptionView = _mapper.Map<SubscriptionView>(subscription);
            else
                subscriptionView = new SubscriptionView();

            response.Subscription = subscriptionView;

            return response;
        }

        

        public async Task<ModifySubscriptionResponse> ModifySubscription(ModifySubscriptionRequest request)
        {
            ModifySubscriptionResponse response = new ModifySubscriptionResponse();
            
            var subscription = await _subscriptionRepository.FindBy(request.SubscriptionId);

            if (subscription == null)
                throw new SubscriptionDoesNotExistException();

            AddPseudoSkusToSubscription(request.PseudoSkusToAdd, subscription);

            UpdateLineQtys(request.ItemsToUpdate, subscription);

            RemoveItemsFromSubscription(request.ItemsToRemove, subscription);
           

            ThrowExceptionIfSubscriptionIsInvalid(subscription);

             await _subscriptionRepository.SaveAll();
            
            //When not using the EF repository, commnit using unit of work
            //_uow.Commit();

           response.Subscription = _mapper.Map<SubscriptionView>(subscription);

            return response;
        }

        private void ThrowExceptionIfSubscriptionIsInvalid(Subscription subscription)
        {
            if (subscription.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the Subscription:");
                foreach (BusinessRule businessRule in subscription.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new ApplicationException(brokenRules.ToString());

            }
        }

         private void AddPseudoSkusToSubscription(IList<int> pseudoSkusToAdd, Subscription subscription)
        {
            PseudoSku pseudoSku;

            if (pseudoSkusToAdd.Count() > 0)
                foreach (int pseudoSkuId in pseudoSkusToAdd)
                {
                    pseudoSku = _pseudoSkuRepository.FindBy(pseudoSkuId);
                    subscription.Add(pseudoSku);                    
                }
        }

         private void UpdateLineQtys(
               IList<PseudoSkuQuantityUpdateRequest> pseudoSkuQtyUpdateRequests, Subscription subscription)
        {
            foreach (PseudoSkuQuantityUpdateRequest pseudoSkuQtyUpdateRequest in
                                                             pseudoSkuQtyUpdateRequests)
            {
                var pseudoSku = _pseudoSkuRepository
                                         .FindBy(pseudoSkuQtyUpdateRequest.PseudoSkuId);

                if (pseudoSku != null)
                    subscription.ChangeQtyOfPseudoSku(pseudoSkuQtyUpdateRequest.NewQty, pseudoSku);
            }
        }

         private void RemoveItemsFromSubscription(IList<int> pseudoSkusToRemove, Subscription subscription)
        {
            foreach (int pseudoSkuId in pseudoSkusToRemove)
            {
                var pseudoSku = _pseudoSkuRepository.FindBy(pseudoSkuId);
                if (pseudoSku != null)
                    subscription.Remove(pseudoSku);
            }
        }
    }
}