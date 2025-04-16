# SauceDemo Test Scenarios

This specification tests basic functionality of the SauceDemo website.

Tags: smoke, regression

## Login functionality

* Navigate to the login page
* Login with username "standard_user" and password "secret_sauce"
* User should be on inventory page

## Add product to cart

* Navigate to the login page
* Login as standard user
* Add product "Sauce Labs Backpack" to cart
* Cart should contain "1" items
* Go to shopping cart
* Cart should contain product "Sauce Labs Backpack"

## Complete a purchase

* Navigate to the login page
* Login as standard user
* Add product "Sauce Labs Fleece Jacket" to cart
* Go to shopping cart
* Cart should contain product "Sauce Labs Fleece Jacket"
* Proceed to checkout
* Fill checkout information with "John", "Doe", "12345"
* Complete the order
* Order should be completed successfully
* Return to home page
* Log out
