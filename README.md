# Posterr (Strider job opportunity)


Local

* Clone Posterr repository
* 


Technologies

* CQRS + Mediator
* Fluent Validation
* 

Notes

* 
* I let the class 'AppUserValidator' in place, but it is not been used since 'AppUser' did not have CRUD operations as defined by assessment document.
* Passing current logged username with parameters for simplicity since the assessment doc tell to not implement authentication


Planning



## Test records

New Post

  {
    "id": "ffff5f64-5717-4562-b3fc-2c963f66afa6",
    "parentId": "",
    "appUserId": "5709c5de-08d5-4547-8de1-1830636576da",
    "text": "Nullam non orci tincidunt, fringilla nisi ut, consectetur ex.",
    "createdAt": "2022-03-31T21:11:08.637Z",
    "appUser": null
  }


Self-Critique and Scaling

* Different databases for commands and queries
  * Optimized database specific for insert/update operations 
  * Optimized document database (eg. MongoDB) for queries
* Edit posts and logical delete
  * Update operations will perform better then cascade delete for deletions
  * Edit might be desireble for users
* Debugger controller to help frontend development
  * Provide a controller with all the possible error responses 
* Authentication
  * Use external auth provider based on JWT 
* Allow change page size
* Create a policy to only allow the post author to edit post information
* 



