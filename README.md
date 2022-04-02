# Posterr 

Posterr is an application that allow users to post, repost and quot-post other users posts.


# Technologies

* .NET5 and C#
* EFCore Code First (Migrations and Seed Data)
* CQRS + Mediator
* Fluent Validation
* SQLite

# Planning

## Reply To Post

Questions

* Users can reply to multiple posts on the same post?
  * There is a limit to the number of posts to mention besides character limits?
* There will be alternative way to mention posts besides at (@) character?

Proposed Solution

* Include a boolean to indicate that posts contains mentions to other posts.
* The mentions will be stored in specific text format containing first 5 to 8 words and at least first 12 characters Guid post identification wich can be shown as hyperlinks on the frontend togheter with respective texts.
* Frontend will generate link and show referenced posts using special formated texts.
* Application layer will check for specific text format on the post to set the post mentions boolean when creating new posts. 
* API will have new endpoints to return all post mentions.

# Critique

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
  * Use Policies for authorization
* Unit and Integration Tests
  * I was not able to set unit tests for different reasons

# Notes

* I was not able to figure out a solution to EF5 with Moq to automatic generate fake dbcontext and other problems to implement the automating and unit tests on the time available.
* I let the class 'AppUserValidator' in place, but it is not been used since 'AppUser' did not have CRUD operations as defined by assessment document.
* Passing current logged username with parameters for simplicity since the assessment doc tell to not implement authentication and I was not able to implement alternative way to create usercontext to simulate validation.
