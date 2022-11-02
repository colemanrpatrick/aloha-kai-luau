@Imports PaymentManagerModels

@modeltype OrderEditViewModel

@code
    Dim lProductOrderCount As Long = 1
    Dim iTabIndex As Integer = 0

    'this to get a list of all groupings and to add a default grouping for prices not already assigned a group
    Dim oGroupings As New List(Of Grouping)
    For Each oProductOrder As ProductOrder In Model.Order.ProductOrders
        If oProductOrder.PriceOrders.Count > 0 Then
            If oGroupings.Where(Function(g) g.Name = oProductOrder.Key).Count = 0 Then
                Dim oPriceOption As New Grouping With {.Name = oProductOrder.Key, .DisplayOrder = oGroupings.Count, .Content = oProductOrder.Product.Title}

                oGroupings.Add(oPriceOption)
            End If
        End If
    Next

End Code

    <div id="accordion">

        @For Each oGrouping As Grouping In oGroupings
            Dim sGroupName As String = oGrouping.Name
            Dim bIsOrder As Boolean = Model.Order.ID > 0
            Dim bHasInvoice As Boolean = False
            Dim lProductOrderID as long = model.order.ProductOrders.single(function(po) po.Key = oGrouping.Name).ID
            Dim lProductID as long = model.order.ProductOrders.single(function(po) po.Key = oGrouping.Name).Product.ID
            For Each oPO As PurchaseOrder In Model.Order.ProductOrders.single(Function(p) p.Key = sGroupName).PurchaseOrders
                If oPO.Invoices.Count > 0 Then
                    bHasInvoice = True
                    Exit For
                End If
            Next

            @<div class="card">
                <div class="card-header" id="@("heading" & sGroupName)">
                    <h5 class="mb-0">
                        <button class="btn btn-block" data-toggle="collapse" data-target="#@("d" & sGroupName)" aria-expanded="true" aria-controls="@("d" & sGroupName)" type="button">
                            @oGrouping.Content
                        </button>
                    </h5>
                </div>


                <div id="@("d" & sGroupName)" class="collapse show" aria-labelledby="@("d" & sGroupName)" data-parent="#accordion">
                    <div class="card-body">
                    	@If bIsOrder Then

    						If Not bHasInvoice Then
                                @<a href="@Url.Action("DeleteProductOrder", "Cart", New With {.ProductOrderKey = sGroupName})" onclick="return confirm('Are you sure you want to remove this item?');"><i class="fas fa-trash"></i>Remove</a>
                                @:&nbsp;
                                @<a href="@Url.Action("Details", "Products", New With {.ID = lProductID})" target="_blank"><i class="fas fa-eye"></i>View</a>
                            Else
            					@<i class="fas fa-exclamation-triangle"></i> @:Invoiced | 
                                @<a href="@Url.Action("Details", "Products", New With {.ID = lProductID})" target="_blank"><i class="fas fa-eye"></i>View</a>

        					End If

                        Else
                            @<a href="@Url.Action("DeleteProductOrder", "Cart", New With {.ProductOrderKey = sGroupName})" onclick="return confirm('Are you sure you want to remove this item?');"><i class="fas fa-trash"></i>Remove</a>
                            @:&nbsp;
                            @<a href="@Url.Action("Details", "Products", New With {.ID = lProductID})" target="_blank"><i class="fas fa-eye"></i>View</a>

        					@<input type="hidden" name="@(New String("productorder_" & lProductOrderCount))" value="@lProductOrderID" />
        					@<input type="hidden" name="@(New String("productorder_" & lProductOrderCount & "_key"))" value="@sGroupName" />
        					@<input type="hidden" name="@(New String("productorder_product_" & lProductOrderCount))" value="@lProductID" />

    					End If
    					<br />

                        <table>
                            <tr>
                                <th>qty</th>
                                <th>description</th>
                                <th>price</th>
                            </tr>

                            @For each oPriceOrder As PriceOrder In Model.Order.ProductOrders.Single(Function(po) po.Key = sGroupName).PriceOrders.tolist

                                @<tr>
                                    <td>
                                        <input name="@(New String("price_" & sGroupName & "_" & oPriceOrder.Price.ID))" class="@("p" & sGroupName)" min="0" value = "@oPriceOrder.Quantity" type="number"/>
                                    </td>
                                    <td>@Html.Raw(oPriceOrder.Price.Description)</td>
                                    <td>

                                        @If oPriceOrder.Price.SalePrice = 0 Then
                	                        @<div class="price-n">@oPriceOrder.Price.ListPrice</div>
                                        Else
                                            @<div class="price-n"><span>@String.Format("{0:c}", oPriceOrder.Price.ListPrice)</span><br />@String.Format("{0:c}", oPriceOrder.Price.SalePrice)</div>
				                        End If

                                    </td>
                                </tr>
 
                            Next

                            <tr>
                                <td colspan="3">
                                	@For Each oScheduleSelection As ScheduleSelection In Model.ScheduleSelections.Where(Function(ss) ss.ProductOrderKey = sGroupName).ToList

                    					@Html.Label(oScheduleSelection.GroupName & " Schedule")

                        				@<select  name="@(New String("schedule_" & htmlutility.ValidControlID(oScheduleSelection.GroupName) & "_" & sGroupName))" title="@oScheduleselection.GroupName">
                            				<option value="">Select @oScheduleSelection.GroupName</option>
                            				@For Each s As Schedule In oScheduleSelection.Members
                                				@<option value="@s.ID"
                                            	@Try
                                                	'the collector type from product.collectors should equal collectorlist.codetable for list type collectors   
                                                	If s.ID = oScheduleSelection.SelectedScheduleID Then
                                                    	@: selected
                                                    End If
                                                Catch ex As Exception

                                                End Try
                                            	>
                                    			@s.Timeslot
                                				</option>
                            				Next
                        				</select>

            						Next

                                </td>
                            </tr>

                            <tr>
                                <td colspan="3">

                					@For Each c As IGrouping(Of String, EntityAttribute) In Model.ProductsInCart.Single(Function(p) p.Key = sGroupName).Collectors.GroupBy(Function(t) CodetableHelper.getCodetableParentForGroup(t.Type))

                        				iTabIndex += 1
                                        Dim oCEAVM As New CartEntityAttributeEditViewModel With {.UniqueKey = sGroupName, .EntityAttribute = c.First, .TabIndex = iTabIndex}
                                        Dim oHeaderCode As Codetable
                                        If c.First.Type.Parent IsNot Nothing Then
                                            oHeaderCode = c.First.Type.Parent
                                        Else
                                            oHeaderCode = c.First.Type
                                        End If


                            			@Html.Label(oHeaderCode.Shortcode) 

                            			Select Case c.First.Type.ApplicationDataType
                                            Case ApplicationDatatype.List

                                                oCEAVM.ListMembers = Model.CollectorLists.Single(Function(cl) cl.Codetable.ID = c.First.Type.ID And cl.ProductOrderKey = sGroupName).Children
                                                oCEAVM.ListMemberID = Model.CollectorLists.Single(Function(cl) cl.Codetable.ID = c.First.Type.ID And cl.ProductOrderKey = sGroupName).SelectedCodetableID

                                    			@Html.Partial("~/Views/Cart/EntityAttributeListEditor.vbhtml", oCEAVM)

                                            Case ApplicationDatatype.MultiSelectList

                                                Dim oCode As Codetable
                                                If c.First.Type.Parent Is Nothing Then
                                                    oCode = c.First.Type
                                                Else
                                                    oCode = c.First.Type.Parent
                                                End If
                                                oCEAVM.CollectorLists.Add(Model.CollectorLists.Single(Function(cl) cl.ProductOrderKey = sGroupName And cl.Codetable.ID = oCode.ID))


                                    			@Html.Partial("~/Designs/common/EntityAttributeMultiSelectListEditor.vbhtml", oCEAVM)

                                            Case ApplicationDatatype.Bit

                                    			@Html.Partial("~/Designs/common/EntityAttributeBitEditor.vbhtml", oCEAVM)

                                            Case Else

                                                Try
                                                    oCEAVM.FunctionScripts.Add(Model.DateScripts.Single(Function(ui) ui.ControlName = c.First.Type.Shortcode And ui.EntityID = sGroupName))
                                                Catch ex As Exception

                                                End Try

                                    			@Html.Partial("~/Designs/common/EntityAttributeSimpleTextEditor.vbhtml", oCEAVM)

                                        End Select
                                        @<br />

                                    Next

                                </td>
                            </tr>
                        </table>
                
                    </div>
                </div>

            </div>
            lProductOrderCount += 1
        Next

    </div>

    <script>
        $(".Spinner").spinner();
    </script>



