Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    ' If all fields are empty, do nothing
    If String.IsNullOrWhiteSpace(txtProductName.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtDescription.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtPrice.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtStockQuantity.Text) AndAlso _
       String.IsNullOrWhiteSpace(cmbCategory.Text) Then
        Return
    End If
    If ValidateProductData() Then
        Try
            ' Get values from textboxes
            Dim productName As String = txtProductName.Text.Trim()
            Dim description As String = txtDescription.Text.Trim()
            Dim price As Decimal = Decimal.Parse(txtPrice.Text.Trim())
            Dim stockQuantity As Integer = Integer.Parse(txtStockQuantity.Text.Trim())
            Dim category As String = cmbCategory.Text.Trim()

            ' Create new product
            Dim newProduct As New Product With {
                .ProductName = productName,
                .Description = description,
                .Price = price,
                .StockQuantity = stockQuantity,
                .Category = category
            }

            ' Add to database
            Using db As New OnlineStoreDBEntities()
                db.Products.Add(newProduct)
                db.SaveChanges()
            End Using

            ' Refresh grid
            LoadProducts()

            ' Clear fields
            ClearFields()

            MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub

Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    ' If all fields are empty, do nothing
    If String.IsNullOrWhiteSpace(txtProductName.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtDescription.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtPrice.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtStockQuantity.Text) AndAlso _
       String.IsNullOrWhiteSpace(cmbCategory.Text) Then
        Return
    End If
    If ValidateProductData() Then
        Try
            ' Get selected product
            Dim selectedProduct As Product = GetSelectedProduct()
            If selectedProduct Is Nothing Then
                MessageBox.Show("Please select a product to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Update product properties
            selectedProduct.ProductName = txtProductName.Text.Trim()
            selectedProduct.Description = txtDescription.Text.Trim()
            selectedProduct.Price = Decimal.Parse(txtPrice.Text.Trim())
            selectedProduct.StockQuantity = Integer.Parse(txtStockQuantity.Text.Trim())
            selectedProduct.Category = cmbCategory.Text.Trim()

            ' Save changes
            Using db As New OnlineStoreDBEntities()
                db.Entry(selectedProduct).State = EntityState.Modified
                db.SaveChanges()
            End Using

            ' Refresh grid
            LoadProducts()

            ' Clear fields
            ClearFields()

            MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End If
End Sub

Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    ' If all fields are empty, do nothing
    If String.IsNullOrWhiteSpace(txtProductName.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtDescription.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtPrice.Text) AndAlso _
       String.IsNullOrWhiteSpace(txtStockQuantity.Text) AndAlso _
       String.IsNullOrWhiteSpace(cmbCategory.Text) Then
        Return
    End If
    Try
        ' Get selected product
        Dim selectedProduct As Product = GetSelectedProduct()
        If selectedProduct Is Nothing Then
            MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm deletion
        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete this product?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Delete from database
            Using db As New OnlineStoreDBEntities()
                db.Products.Remove(selectedProduct)
                db.SaveChanges()
            End Using

            ' Refresh grid
            LoadProducts()

            ' Clear fields
            ClearFields()

            MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    Catch ex As Exception
        MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

Private Function ValidateProductData() As Boolean
    ' Only validate if any field has been modified
    If String.IsNullOrWhiteSpace(txtProductName.Text) AndAlso
       String.IsNullOrWhiteSpace(txtDescription.Text) AndAlso
       String.IsNullOrWhiteSpace(txtPrice.Text) AndAlso
       String.IsNullOrWhiteSpace(txtStockQuantity.Text) AndAlso
       String.IsNullOrWhiteSpace(cmbCategory.Text) Then
        Return True
    End If

    ' Validate Product Name
    If String.IsNullOrWhiteSpace(txtProductName.Text) Then
        MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtProductName.Focus()
        Return False
    End If

    ' Validate Description
    If String.IsNullOrWhiteSpace(txtDescription.Text) Then
        MessageBox.Show("Please enter a product description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtDescription.Focus()
        Return False
    End If

    ' Validate Price
    If String.IsNullOrWhiteSpace(txtPrice.Text) Then
        MessageBox.Show("Please enter a product price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtPrice.Focus()
        Return False
    End If

    Dim price As Decimal
    If Not Decimal.TryParse(txtPrice.Text.Trim(), price) OrElse price <= 0 Then
        MessageBox.Show("Please enter a valid price greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtPrice.Focus()
        Return False
    End If

    ' Validate Stock Quantity
    If String.IsNullOrWhiteSpace(txtStockQuantity.Text) Then
        MessageBox.Show("Please enter a stock quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtStockQuantity.Focus()
        Return False
    End If

    Dim stockQuantity As Integer
    If Not Integer.TryParse(txtStockQuantity.Text.Trim(), stockQuantity) OrElse stockQuantity < 0 Then
        MessageBox.Show("Please enter a valid stock quantity (0 or greater).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtStockQuantity.Focus()
        Return False
    End If

    ' Validate Category
    If String.IsNullOrWhiteSpace(cmbCategory.Text) Then
        MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        cmbCategory.Focus()
        Return False
    End If

    Return True
End Function

Private Sub ClearFields()
    txtProductName.Clear()
    txtDescription.Clear()
    txtPrice.Clear()
    txtStockQuantity.Clear()
    cmbCategory.SelectedIndex = -1
End Sub

Private Function GetSelectedProduct() As Product
    If dgvProducts.SelectedRows.Count > 0 Then
        Dim productId As Integer = CInt(dgvProducts.SelectedRows(0).Cells("ProductID").Value)
        Using db As New OnlineStoreDBEntities()
            Return db.Products.Find(productId)
        End Using
    End If
    Return Nothing
End Function 