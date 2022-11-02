@Imports PaymentManagerModels

@modeltype OrderEditViewModel

<section class="checkout-section">
    <div class="container">
        <!-- checkout form  -->
        
            <label>First Name</label>
            <input type="text" name="CustomerFirstName" value="@Model.Order.Customer.FirstName" /><br />

            <label>Last Name</label>
            <input type="text" name="CustomerLastName" value="@Model.Order.Customer.LastName" /><br />

            <label>Street</label>
            <input type="text" name="CustomerAddress" value="@Model.Order.Customer.Addresses(0).Address" /><br />

            <label>City</label>
            <input type="text" name="CustomerCity" value="@Model.Order.Customer.Addresses(0).City" /><br />

            <label>State</label>
            <input type="text" name="CustomerRegion" value="@Model.Order.Customer.Addresses(0).Region" /><br />

            <label>Postal Code</label>
            <input type="text" name="CustomerPostalCode" value="@Model.Order.Customer.Addresses(0).PostalCode" /><br />

            <label>Country</label>
            <input type="text" name="CustomerCountry" value="@Model.Order.Customer.Addresses(0).Country" /><br />

            <label>Email Address</label>
            <input type="email" name="CustomerPrimaryEmail" value="@Model.Order.Customer.PrimaryEmail" /><br />

            <label>Mobile Phone</label>
            <input type="text" name="CustomerMobilePhone" value="@Model.Order.Customer.MobilePhone" /><br />
        
    </div>
</section>
