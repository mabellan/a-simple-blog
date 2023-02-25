# A Simple Blog
## Purpose
This project was created in order to share my knowladge in Software Development. The principal idea was to create a simple blog with 
Hexagonal Architecture and CQRS pattern. The idea was not to create a full blog, just a piece of that where you can create a post, update it and list all 
the available post.

## API endpoints
The main actions you can do with this API are:
1. Create a new post: POST: `/api/posts`
2. Update an existing post. PUT: `/api/posts`
3. Make post available or mark an available one as a draft. PATCH: `/api/posts`
4. Swagger: `/swagger`

## Project structure
The project uses the following patterns, architectures and technologies:
+ Hexagonal architecture
+ SOLID
+ CQRS pattern (Command Bus Pattern and Query Bus Pattern)
+ Application Dockerized with Docker Compose.

## Github actions
I've created an action that runs the tests in every Pull Request to verify the code.

## Run locally the application
1. GIT clone.
2. Start Docker Desktop or Docker deamon.
3. Open a terminal and go to the folder `/simple-blog`.
4. Run `docker-compose up -d`
5. Open your browser and open `http://localhost/swagger`

## TODO:
+ Add more actions.
+ Improve the tests.
+ Improve CQRS pattern.

If you have a recomendation, please, let me know and I will try to add the feature :)
