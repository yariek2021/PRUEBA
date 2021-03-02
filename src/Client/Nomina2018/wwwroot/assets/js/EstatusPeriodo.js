
<script>

    var app = new Vue({
        el: '#EstatusPeriodo',
            data:{
                @*PeriodosNomina: @Html.Raw(@Newtonsoft.Json.JsonConvert.SerializeObject(@Model.PeriodosNomina)),
    Hoteles: @Html.Raw(@Newtonsoft.Json.JsonConvert.SerializeObject(@Model.Hoteles)),
    Areas: @Html.Raw(@Newtonsoft.Json.JsonConvert.SerializeObject(@Model.Areas)),*@
  
},
            created: function (){


    },
            methods: {
        ActualizaEstatus() {
    @*if (this.FactorActual > 0) {
        $.ajax({
            url: '@Url.Action("UpdateFactorProductividad", "Nomina")',
            type: "POST",
            data: {
                PeriodoId: this.PeriodoActual, // Parámetros
                UsuarioId: this.selectedVcs,
                FactorProductividad: this.FactorActual
            },
            //contentType: false,
            success: data => {

                var datos = JSON.parse(data);
                this.loadDatos();
                //alert(datos.Message);
                if (datos.Message != '') {

                    Swal.fire(
                        'Actualizado!',
                        '',
                        'success'
                    )
                }

            },
            failure: function (data) {
                console.log(data.responseText);
            },
            error: function (data) {
                console.log(data.responseText);
            },
        })
    }*@

                    //Swal.fire({
        //    title: 'Submit your Github username',
        //    input: 'text',
        //    inputAttributes: {
        //        autocapitalize: 'off'
        //    },
        //    showCancelButton: true,
        //    confirmButtonText: 'Look up',
        //    showLoaderOnConfirm: true,
        //    preConfirm: (login) => {
        //        return fetch(`//api.github.com/users/${login}`)
        //            .then(response => {
        //                if (!response.ok) {
        //                    throw new Error(response.statusText)
        //                }
        //                return response.json()
        //            })
        //            .catch(error => {
        //                Swal.showValidationMessage(
        //                    `Request failed: ${error}`
        //                )
        //            })
        //    },
        //    allowOutsideClick: () => !Swal.isLoading()
        //}).then((result) => {
        //    if (result.value) {
        //        Swal.fire({
        //            title: `${result.value.login}'s avatar`,
        //            imageUrl: result.value.avatar_url
        //        })
        //    }
        //})


        Swal.fire({
            title: 'Estas seguro?',
            text: "Ya no se podran realizar cambios a los datos del Periodo " + $("#PeriodoAnterior").val(),
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Cerrar Periodo!',
            allowOutsideClick: () => !Swal.isLoading()
        }).then((result) => {
            if (result.value) {
                Swal.fire(
                    'Cerrado!',
                    'El Estatus del periodo se ha actualizado',
                    'success'
                )
            }
        })



    }
    }

})

    </script>

