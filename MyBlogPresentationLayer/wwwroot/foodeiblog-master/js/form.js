//Yorum Ekleme
$(document).ready(function () {
    $("#btnComment").click(function () {

        $.ajax({
            type: "POST",
            url: "/Comment/CreateComment/",
            data: $("#commentForm").serialize(),
            dataType:"json",
            encode: true,
        })
            .done(function (data) {

                Swal.fire(
                    'Yorum başarıyla eklendi',
                    '',
                    'success'
                ),
                console.log(data);
            })
            .fail(function (data) {
                Swal.fire(
                    'Yorum eklenemedi',
                    data,
                    'error'
                ),
                    console.log(data);
            });
    });
});