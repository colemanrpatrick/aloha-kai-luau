@Imports PaymentManagerModels

@ModelType IOrderViewModel

<div Class="cart-edit-bottom">
    @If Not IsNothing(Model.Order) Then
        @<p><span>Total </span>@String.Format("{0:c}", (Model.OrderDisplayTotal.LineItemTotal + Model.OrderDisplayTotal.LineItemExemptTotal))</p>
        @<p><span>Processing Fee Total </span>@String.Format("{0:c}", Model.OrderDisplayTotal.LineItemPCTTotal)</p>
        @<p><span>Other Fee Total </span>@String.Format("{0:c}", Model.OrderDisplayTotal.LineItemFlatTotal)</p>
        @<p><span>Discount Total </span>@String.Format("{0:c}", Model.Order.OrderDiscount) </p>
        @<p><span>Your OrderTotal is </span>@String.Format("{0:c}", (Model.Order.OrderTotal + Model.Order.OrderShipping + Model.Order.OrderSalesTax + Model.Order.OrderAdjust)) <br /></p>
    End If
</div>