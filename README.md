# ProductApp
Simple RESTful web service that performas CRUD operations for _Products_.

## How to run

Standard Visual Studio way to run/test the application.

## Features implemented

### EntityFrameword in-memory database

For simplicity, I chose EF in-memory database.

### Unit testing covers Controllers

For good programming practice, we should achieve >80% unit testing coverage. Due to time limitation, this project has only controller covered.

### JWT Bearer authentication covered _Create_, _Update_ and _Delete_.

We should have _Role Based Access Control_ to have a achieve better authentication/authorisation practice. Due to time limitation, I only implemented the most basic authentication, i.e. protect the _non-idempotent_ operations.