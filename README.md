# Confirm Coords (Service part 2)
Confirm Coords part of microservice project.

Solution use: 
* RabbitMQ for sending communicate with another microservices.
* EF_Core for storing data.

Full project contains:
* [Coords API (part 1)](https://github.com/Unguryan/Coords_API_p1)
* [Confirm Coords API (part 2)](https://github.com/Unguryan/Coords_Confirm_p2)
* [Angular (part 3)](https://github.com/Unguryan/Coords_Angular_p3)
* [Telegram Service (part 4)](https://github.com/Unguryan/Coords_Telegram_p4)

# Installation

* For Default install: 

Just run the project.


# For using in Docker container: 

Create network:
    
```bash
PM> docker network create coords_net 
```

Build up:
    
```bash
PM> docker-compose up
```


