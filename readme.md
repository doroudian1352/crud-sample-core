# CRUD Code Sample
 


Sample is a simple CRUD application with ASP NET Core that implements the below model:
```
Customer {
	Firstname
	Lastname
	DateOfBirth
	PhoneNumber
	Email
	BankAccountNumber
}
```
## Design Pattern

- I Use Clean Design Pattern.
- Ui Layer Has client and server and Domain,Service and Common implemented in share project ,they are in Mc2.CrudTest.Presentation folder
- Persistence Layer is in different project and folder in root
- Test Project for test services Mc2.CrudTest.VerfiyTests


### We Used:
- Blazor Web.
- validate the phone number to be a valid *mobile* number only By [Google LibPhoneNumber](https://github.com/google/libphonenumber) .



