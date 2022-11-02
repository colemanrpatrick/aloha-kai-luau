@Imports PaymentManagerModels
@imports microsoft.visualbasic
@Layout Layout.vbhtml
@ModelType OrderEditViewModel
@Code
    ViewData("Title") = "Edit Shopping Cart"
End Code
<a id="viewitems"></a>


<div class="checkpoint">
    <section Class="post">
        <form action="@Url.Action("Edit","Cart")" class="price-form" method="post">
            <div Class="container">


                @Html.AntiForgeryToken()
                <div Class="row">
                    <div Class="col-md-12 col-lg-4 order-0 order-md-0">
                        @Html.Partial("~/Designs/common/CartCustomerEdit.vbhtml", Model)
                    </div>
                    <div Class="col-md-12 col-lg-8 order-1 order-md-1">
                        @Html.Partial("~/Designs/common/CartItemsEdit.vbhtml", Model)
                        @Html.Partial("~/Designs/common/OrderTotals.vbhtml", Model)
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <button type="submit" name="submit" id="input-2" Class="btn btn-block" @IIf(Len(Model.Order.OrderNumber) > 0, "disabled", "") value="Update Cart">Update Cart</button>
                    </div>
                    <div class="col-sm-6">
                        <button type="submit" name="submit" id="input-1" Class="btn btn-block" @IIf(Len(Model.Order.OrderNumber) > 0, "disabled", "") onclick="return confirm('Are you sure you want to empty your cart?');" value="Empty Cart" formnovalidate>Empty Cart</button>
                    </div>
                </div>

            </div>
        </form>
        <div class="container">
            <div class="row">
                <div class="col-sm-12">

                    @If Model.ApplicationUser IsNot Nothing Then
                        @<button type="submit" name="submit" id="input-3" class="btn btn-block" @IIf(Len(Model.Order.OrderNumber) > 0, "disabled", "") value="Create Order">Create Order</button>
                    Else
                        @Html.Partial("~/Designs/sealifeparkluau/Checkout.vbhtml", Model.CheckoutViewmodel)

                    End If
                </div>
            </div>
        </div>
    </section>
</div>



<script type="text/javascript">
    $("[name^='Order.Customer']").removeAttr("data-val-required");

</script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/jquery.validate.min.js" integrity="sha512-UdIMMlVx0HEynClOIFSyOrPggomfhBKJE28LKl8yR3ghkgugPnG6iLfRfHwushZl1MOPSY6TsuBDGPK2X4zYKg==" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.2/additional-methods.min.js" integrity="sha512-6Uv+497AWTmj/6V14BsQioPrm3kgwmK9HYIyWP+vClykX52b0zrDGP7lajZoIY1nNlX4oQuh7zsGjmF7D0VZYA==" crossorigin="anonymous"></script>
@html.raw(model.ValidationScript)
