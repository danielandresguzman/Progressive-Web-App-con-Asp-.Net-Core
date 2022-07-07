var nombreCacheEstatico = "cacheEstatico1"
var nombreDinamico = "cacheDinamico1"

var archivosEstaticos = [
    "/css/menu.css", "/MiProgressApp.styles.css", "/lib/jquery/dist/jquery.min.js",
    "/lib/bootstrap/dist/js/bootstrap.bundle.min.js", "/js/menu.js", "/", "/js/generic.js", "/img/loading.gif", "/Persona/listarPersonas"
]

self.addEventListener("install", event => {
    console.log("evento install")
    //para que el codigo que escriba pase al activate
    event.waitUntil(
        caches.open(nombreCacheEstatico).then(cache => {
            return cache.addAll(archivosEstaticos)
        })
    )

})

self.addEventListener("activate", event => {
    console.log("evento activate")
    event.waitUntil(self.clients.claim())
})

self.addEventListener("fetch", event => {
    const respuesta = caches.match(event.request).then(res => {
        if (res) return res
        else {
            return fetch(event.request).then(response => {
                caches.open(nombreDinamico).then(cache => {
                    cache.put(event.request,response)
                })
                return response.clone;
            })
        }
    }).catch(err => {
        return null;
    })
    //if (event.request.url =="https://localhost:7081/css/menu.css"){
    //    event.respondWith(null);
    //} else
    //console.log(event.request.url)
    event.respondWith(respuesta)

})