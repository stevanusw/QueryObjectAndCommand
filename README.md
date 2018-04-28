# QueryObjectAndCommand
An example of using query object and command pattern in EF Core.

With query object pattern, we can have a slim repository with a single Get and GetAll method.
This is because the predicates have become objects that are passed to the methods.
