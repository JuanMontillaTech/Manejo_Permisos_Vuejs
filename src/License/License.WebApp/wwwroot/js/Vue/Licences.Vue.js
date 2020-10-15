var app = new Vue({
    el: '#app',
    data: {
        LicenseList: []
    },
    methods: {
        GetListLicense: function  () {
            axios.get("/License/GetAllLicenses").then(function (response) {
                this.LicenseList = null;
                app.LicenseList = response.data;
            })
                .catch(function (error) {
                    console.log(error)
                });
        },
        DeleteLicense: function (e) {

            axios.post("/License/DeleteLicense?Id=" + e).then(function (response) { 
                this.GetListLicense()
            })
                .catch(function (error) {
                    console.log(error)
                });

        },
       ConfirmarEliminar: function (_Id, _name) {
        Swal.fire({
            title: 'Quiere Eliminar este registro? </br>' + _name,
            showDenyButton: true, 
            confirmButtonText: `Eliminar`,
            denyButtonText: `Cancelar`,
        }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                this.DeleteLicense(_Id);
                window.location.href = "/License/";
                Swal.fire('Registro Eliminado!', '', 'success')
               
            } else if (result.isDenied) {
                Swal.fire('No se realizo cambios', '', 'info')
            }
        })
    }
    },
    created: function () {
        this.GetListLicense()
      

    }
})