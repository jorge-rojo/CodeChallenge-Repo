var $owlCarousel = null;
var $chart = null;

$(function () {

    //Validate Form
    $("form").validate({
        errorClass: 'is-invalid',
        validClass: 'is-valid',
        rules: {
            Url: {
                required: true,
                url: true
            }
        },
        submitHandler: function (form) {
            //Ajax submit handler
            LoadUrl(form, $(form).serialize());
        },
        errorPlacement: function (error, element) {

            $(element).parent().find('.invalid-feedback').html(error[0].innerText);
        }

    });

});

/*
 * 
 * @param {any} form
 * @param {any} url
 */
function LoadUrl(form, url) {
    var prevText = '';
    var $button = $(form).find("button");
    $.ajax({
        url: form.action,
        type: "Post",
        data: url,
        beforeSend: function () {
            prevText = $button.text();
            $button.text("Loading Url...");
        },
        success: function (result) {
            $button.text(prevText);
            if (result.Data && result.Data.SuccessRequest) {

                $("html").find(".no-data").addClass("d-none");

                //get top ten ranked words

                var topTenRankedWords = result.Data.WordsRankedList.slice(0, 10);

                var totalWordCount = result.Data.TotalWordCount;

                $("#total-word-count").text("Total Words in Site: " + totalWordCount);

                var ctx = $('#TopTenWordsChart');

                //Create Chart
                CreateChart(ctx, topTenRankedWords);

                //Create Carousel
                if ($owlCarousel) {
                    $owlCarousel.trigger("destroy.owl.carousel");
                    $owlCarousel.html('');
                }

                $.each(result.Data.ImagesSources, function (index, url) {
                    $('<img>', { src: url }).appendTo(".owl-carousel");
                });

                $owlCarousel = $(".owl-carousel").owlCarousel({
                    dots: true
                });
            }
            else {
                //Error State Clean all elements
                $("html").find(".no-data").removeClass("d-none");

                if ($owlCarousel) {
                    $owlCarousel.trigger("destroy.owl.carousel");
                    $owlCarousel.html('');
                }

                if ($chart)
                    $chart.destroy();
            }
        }
    });

}

/*
 * 
 * @param {any} ctx
 * @param {any} dataSet
 */
function CreateChart(ctx, dataSet) {

    var labels = $.map(dataSet, function (n, i) {
        return (n.Text);
    });

    var data = $.map(dataSet, function (n, i) {
        return (n.Occurrences);
    });

    if ($chart)
        $chart.destroy();

    $chart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: "Top Ten Words in the website",
                data: data,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.6)',
                    'rgba(54, 162, 235, 0.6)',
                    'rgba(255, 206, 86, 0.6)',
                    'rgba(75, 192, 192, 0.6)',
                    'rgba(153, 102, 255, 0.6)',
                    'rgba(255, 159, 64, 0.6)',
                    'rgba(255, 206, 86, 0.6)',
                    'rgba(75, 192, 200, 0.6)',
                    'rgba(153, 102, 74, 0.6)',
                    'rgba(255, 159, 24, 0.6)'
                ]
            }]
        }
    });
}