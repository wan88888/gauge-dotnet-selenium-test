# Multiple Items Purchase Flow

This specification tests the ability to purchase multiple items at once on the SauceDemo website.

Tags: regression, cart

## Purchasing Multiple Items

* Navigate to the login page
* Login as standard user
* Add product "Sauce Labs Backpack" to cart
* Add product "Sauce Labs Bike Light" to cart
* Add product "Sauce Labs Bolt T-Shirt" to cart
* Cart should contain 3 items
* Go to shopping cart
* Cart should contain product "Sauce Labs Backpack"
* Cart should contain product "Sauce Labs Bike Light"
* Cart should contain product "Sauce Labs Bolt T-Shirt"
* Proceed to checkout
* Fill checkout information with "Jane", "Smith", "54321"
* Complete the order
* Order should be completed successfully
* Return to home page
* Log out 