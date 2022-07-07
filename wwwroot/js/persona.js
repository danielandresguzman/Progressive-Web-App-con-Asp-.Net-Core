window.onload = function () {
    listarPersonas();
}

function listarPersonas() {
    pintar({
        url: "Persona/listarPersonas",
        propiedades: ["nombrecompleto", "correo"],
        cabeceras:["Nombre Completo","Correo"]
    })
}