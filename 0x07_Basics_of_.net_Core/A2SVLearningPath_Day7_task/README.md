# BlogApp
This application is a blogging platform developed using ASP.NET Core Web API. The primary objective of this endeavor was to leverage EF Core for seamless integration of PostgreSQL with .NET development. The approach chosen to enable user access was the implementation of a RESTful API. Additionally, the project incorporates a dedicated testing module that encompasses comprehensive unit tests for the application.
## Postman Documentation
[Documentation]((https://documenter.getpostman.com/view/20871920/2s9Xy3trfU#intro))

## Table of Contents
1. [Features](#features)
2. [Code Organization](#code-organization)
3. [Endpoints](#endpoints)

## Features
Users can add their posts and can also comment on blog posts.

## Code Organization
The code is organized into the following folders:
```bash
├── 0x07_Basics_of_.net_core: A2SVLearningPath_Day7_task
│   ├── A2SVLearningPath_Day7_task
│   │   ├── Controllers
│   │   │   ├── CommentManager.cs
│   │   │   ├── PostManager.cs
│   │   ├── Data
│   │   │   ├── ApiDbContext.cs
│   │   ├── Models
│   │   │   ├── Comment.cs
│   │   │   ├── Post.cs
│   │   ├── appsettings.Development.json
│   │   ├── A2SVLearningPath_Day7_task.csproj
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   ├── TestUnit
│   ├── A2SVLearningPath_Day7_task.sln
│   ├── README.md
```

## Endpoints
![image](https://github.com/abneka/A2SV_backend_learning_path/blob/main/assets/api%20end%20point.png)
The end-points of this application can be generally divided into two categories: [Post](#1-post) and [Comment](#2-comment).
The end-points of this api are based on the REST architecture. The request and response formats are in JSON. They are described below. Then the end points will follow:
### 1. Post
#### Request Format
```js
{
  "postId": 0,
  "title": "string",
  "content": "string",
  "createdAt": "2023-08-10T18:49:21.572Z",
  "comments": []
}
```

#### Response Format
```js
{
  "postId": 0,
  "title": "string",
  "content": "string",
  "createdAt": "2023-08-10T18:50:13.025Z",
  "comments": [
    {
      "commentId": 0,
      "postId": 0,
      "text": "string",
      "createdAt": "2023-08-10T18:50:13.025Z"
    }
  ]
}
```
#### Endpoints
##### Get all posts
```js
GET /api/PostManager
```

##### Get post by id
```js
GET /api/PostManager/{id}
```

##### Create post
```js
POST /api/PostManager
```

##### Update post
```js
PUT /api/PostManager
```

##### Delete post
```js
DELETE /api/PostManager
```

### 2. Comment
#### Request Format
```js
{
  "commentId": 0,
  "postId": 0,
  "text": "string",
  "createdAt": "2023-08-10T18:52:32.514Z"
}
```

#### Response Format
```js
{
  "commentId": 0,
  "postId": 0,
  "text": "string",
  "createdAt": "2023-08-10T18:52:32.514Z"
}
```

#### Endpoints
##### Get all comments
```js
GET /api/CommentManager/{postId}
```

##### Create comment
```js
POST /api/CommentManager
```

##### Update comment
```js
PUT /api/CommentManager
```

##### Delete comment
```js
DELETE /api/CommentManager
```
