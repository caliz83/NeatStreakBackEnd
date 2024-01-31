Controllers _folder_
UserController
Login?/endpoints
Add a user/endpoints
Delete a user

ChoreController _file_

add chores (C)
ViewAllChores (R)
ViewChoresByCategory (R) (kitchen, bathroom, bedroom, yard, garage, etc)
ViewChoresByDueDate (R)
UpdateChores (U)
DeleteChores (D)

Models _folder_
UserModel
int id
string username
string salt
string hash 256 characters

    ChoreModel
    	int id
    	int userid
    	string chore title
    	string chore description
    	string image (basic images chosen for vacuuming, mopping, etc, fallback images by category for ones that don't match a pre-chosen image)
    	string date
    	string category
    	bool isDeleted

** items above will be saved to database**

LoginModelDTO
string username
string password

CreateAccountModelDTO
int id = 0
string username
string password

passwordModelDTO
string salt
string hash

Services _folder_
Context _folder_

    UserService *file*
    	Login
    	Add User
    	Delete User

    ChoreService *file*
    	Add chores (C)
    	ViewAllChores (R)
    	ViewChoresByCategory (R) (kitchen, bathroom, bedroom, yard, garage, etc)
    	ViewChoresByDate (R)
    	UpdateChores (U)
    	DeleteChores (D)

    PasswordService *file*
    	hash password

Server Admin login: ChoreAdmin Password:ChawrProjectPassword!


