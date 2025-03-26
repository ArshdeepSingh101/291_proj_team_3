# Input Validation Test Cases

This document provides detailed test cases for validating the input fields in the Movie form. Use these to thoroughly test the validation logic and ensure data integrity.

## String Field Validation

### Movie ID Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid ID | "M123" | Accepted |
| Empty ID | "" | Error message about required field |
| Very Long ID | "M12345678901234567890" | Should truncate or reject if too long |
| Special Characters | "M123#$%" | Should validate based on business rules |
| Spaces Only | "   " | Error message about required field |
| Spaces Between | "M 123" | Should trim or reject based on business rules |

### Movie Name Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid Name | "The Matrix" | Accepted |
| Empty Name | "" | Error message about required field |
| Very Long Name | "This is an extremely long movie title that goes on and on..." | Should truncate or have scrollable field |
| Special Characters | "Movie: Special #1" | Should accept (movie titles can have special chars) |
| Numbers Only | "12345" | Should accept if business rules allow |
| HTML/SQL Injection | "<script>alert('test')</script>" or "'; DROP TABLE Movies;--" | Should sanitize input |

### Movie Type Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid Selection | Select "Action" from dropdown | Accepted |
| No Selection | Leave dropdown at default | Error message if required |
| Custom Entry (if allowed) | Type "New Category" | Depends on UI configuration |

### Movie Rating Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid Rating | "PG-13" | Accepted |
| Empty Rating | "" | Error message if required |
| Invalid Rating | "ABC" | Should validate against allowed ratings |
| Numeric Rating | "7.5" | Should validate based on rating system |

## Numeric Field Validation

### Distribution Fee Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid Decimal | "12.99" | Accepted |
| Zero Value | "0" | Should accept if business rules allow |
| Negative Value | "-10.99" | Should reject with error message |
| Non-Numeric | "abc" | Error message about invalid numeric value |
| Too Many Decimals | "12.9876" | Should round or reject based on rules |
| Very Large Value | "999999.99" | Should validate against maximum allowed |
| With Currency Symbol | "$12.99" | Should reject and request number only |

### Number of Copies Field

| Test Case | Input Value | Expected Result |
|-----------|-------------|-----------------|
| Valid Integer | "10" | Accepted |
| Zero Value | "0" | Should accept if business rules allow |
| Negative Value | "-5" | Should reject with error message |
| Decimal Value | "10.5" | Should reject or truncate based on business rules |
| Non-Numeric | "abc" | Error message about invalid numeric value |
| Very Large Value | "99999" | Should validate against maximum allowed |

## Cross-Field Validation

| Test Case | Scenario | Expected Result |
|-----------|----------|-----------------|
| Logical Value Check | Distribution Fee higher than expected for Type | Warning or confirmation dialog |
| Duplicate Prevention | Add movie with ID that already exists | Error about duplicate ID |
| Required Fields | Fill some fields but leave others empty | Error listing all required fields |

## Form Operation Tests

| Test Case | Scenario | Expected Result |
|-----------|----------|-----------------|
| Rapid Input | Quickly enter data and submit | Form should handle without errors |
| Multiple Saves | Add same data twice | Second attempt should fail with duplicate error |
| Cancel Operation | Start adding then cancel | Form should return to initial state |
| Clear Fields | Use Clear button if available | All fields should reset to empty/default |
| Accidental Key Press | Press random keys on keyboard | Should not trigger unintended actions |

## UI Responsiveness Tests

| Test Case | Scenario | Expected Result |
|-----------|----------|-----------------|
| Field Tab Order | Tab through fields | Should follow logical order |
| Error Focus | Submit with errors | Focus should move to first error field |
| Dropdown Performance | Click dropdown with many items | Should open quickly without lag |
| Form Resize | Resize the window | Form elements should adjust appropriately |
| Button Visibility | Scroll if form is long | Action buttons should remain accessible |

## Database Error Handling

| Test Case | Scenario | Expected Result |
|-----------|----------|-----------------|
| Connection Loss | Disconnect network during save | Appropriate error message |
| DB Constraint Violation | Violate a DB constraint not caught by UI | Clear error message explaining issue |
| Concurrent Edits | Two users edit same record (simulate in code) | Proper handling of conflict |

## Recovery Tests

| Test Case | Scenario | Expected Result |
|-----------|----------|-----------------|
| After Validation Error | Fix error and resubmit | Should accept valid submission |
| After DB Error | Resolve DB issue and retry | Should complete operation |
| Form Reset | Add data, reset form, add again | Should work correctly both times |

## How to Use This Test Matrix

1. Work through each test category systematically
2. For each test case:
   - Set up the initial conditions
   - Perform the specified input or action
   - Verify the actual result matches the expected result
   - Document any discrepancies
3. If a test fails, fix the issue and retest
4. Mark each test as Pass/Fail/Not Applicable

This comprehensive testing approach ensures your Movie form can handle real-world usage patterns and edge cases while maintaining data integrity.
