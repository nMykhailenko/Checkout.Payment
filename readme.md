# Payment Gateway

## Solution structure

1. Payment.Gateway - the API base on CQRS design patterns.
2. Application - contains all business logic.
3. Domain - contains entities and value objects.
4. Persistence - contains dbcontext, migrations and models configuration.
5. Common - contains contract for application configuration, custom middleware, extensions, filters, specific model.
6. BankProccessing - background hosted service which proccesses the bank payment (BankService Mock).

## Payment Flow

 1. You need to send **POST** request via /api/payment.
 2. You will receive payment in **Pending** status.
 3. In background your request will be sent to bank and in a while the BankProccessing will send the event to payment gateway with bank reques id and payment status.
 4. You can find payment information via /api/payment/{requestId}.

## TODO

 1. Add Authorization. For example, IdentityServer.
 2. Add integration/unit, pefomance tests.
 3. Add more custom metrics and finish setup prometheus/graphana.
 4. Add background checker. Move payment to status expired if bank not proccessed your payment.