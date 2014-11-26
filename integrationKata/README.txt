Goal
You boss has asked you make a program that will encrypt a list of passwords, and then return them as a comma separated string along with the associated username.
The users should be sorted alphabetically.

Rules
The password encryption will be reversing the order of the characters (the boss claims this is for backward compatibility reasons).
For example, "password123" should become "321drowssap"

The usernames should be ordered alphabetically, ignoring case.
"Billy", "alfred", "Abe" should become "Abe", "alfred", "Billy"

When the final program is given an username and password string of the form:
"username, password
username2, password2
username3, password3"

It should reorder the lines by username and encrypt the passwords, then return a string of the same form.
"username, drowssap"... etc
