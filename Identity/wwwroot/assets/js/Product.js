$(function () {

    $('.addToBasket').on('click', function () {
        $.ajax({
            method: "POST",
            url: "/basket/AddProduct",
            data: {
                productId: $(this).data('id')
            },
            success: function (response) {
                alert(response)
            },
            error: function (response) {
                alert(response)
            }
        });
    })
})