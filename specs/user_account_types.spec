# Different User Account Types

This specification tests the behavior of different user account types on the SauceDemo website.

Tags: regression, user-accounts, smoke

## Various Login Scenarios

* Navigate to the login page
* Login with username "locked_out_user" and password "secret_sauce"
// This should not work as this user is locked out

* Navigate to the login page
* Login with username "problem_user" and password "secret_sauce"
* User should be on inventory page
// This user can login but has various issues on the site

* Navigate to the login page
* Login with username "performance_glitch_user" and password "secret_sauce"
* User should be on inventory page
// This user experiences performance glitches

* Navigate to the login page
* Login with username "standard_user" and password "secret_sauce"
* User should be on inventory page
// Standard user works as expected 