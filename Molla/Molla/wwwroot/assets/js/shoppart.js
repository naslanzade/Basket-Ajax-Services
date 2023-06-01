$(function () {

    $(document).on('click', '.each-category span a', function (e) {
        e.preventDefault();
        let category = $(this).attr('data-id');       
        let products = $('.each-cards');
       
        products.each(function () {
            if (category == $(this).attr('data-id')) {
                $(this).removeClass('d-none');                
            }
            else {
                $(this).addClass('d-none');
            }
        })
        if (category == 11) {
            products.removeClass('d-none');
        }

    })








})