# posterr

Strider job opportunity


Technologies

* CQRS + Mediator
* Fluent Validation
* 


Notes

* I let the class 'AppUserValidator' in place, but it is not been used since 'AppUser' did not have CRUD operations as defined by assessment document.


Planning



Self-critique and Scaling

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
