# A Simple Blog
## Purpose
This project was created in order to share my knowladge in Software Development. The principal idea was to create a simple blog with 
Hexagonal Architecture and CQRS pattern. The idea was not to create a full blog, just a piece of that where you can create a post, update it and list all 
the available post.

## Actions
The main actions you can do with this API are:
1. Create a new post: POST: `/api/posts`
2. Update an existing post. PUT: `/api/posts`
3. Make post available or mark an available one as a draft. PATCH: `/api/posts`

## Project structure
The project uses the following patterns, architectures and technologies:
+ Hexagonal architecture
+ SOLID
+ CQRS pattern (Command Bus Pattern and Query Bus Pattern)
+ A database Dockerized.

## TODO:
+ Add more actions.
+ Improve the tests.
+ Improve CQRS pattern.

If you have a recomendation, please, let me know and I will try to add the feature :)