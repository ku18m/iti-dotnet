============================================================================
============================================================================

- Tried to take a small challange to make the Last project that depends on Scaffolded Context
  Works well with the new Context without changing the code.

- I've created the same classes with the same columns names and the same constrains.

- I've only changed 1 line in the old project logic which is the Course Id generator on creation.
  Because it's now an Identity column.

============================================================================

- To avoid build errors, I kept the old context while executing the migration commands.
  But I faced an error 'There's more than one context' So I had to use the -Context flag to specify the context.
  To keep testing the project.

============================================================================

- As a DB developer I can copy the old data to the new DB using SQL select into script.

- I can do it using C# code but it's not recommended because it's not efficient,
  and it's not the best practice.

- I've searched for a way to do it using EF Core but I didn't find a way to do it,
  Always faced the answer 'EF is not designed for ETL (Extract, transform, and load)'.

- Finally, I can use the SQL script to do it in a few seconds.
  
============================================================================
============================================================================