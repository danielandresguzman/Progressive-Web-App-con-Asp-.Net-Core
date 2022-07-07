var nombreCacheEstatico = "cacheEstatico1"
var nombreCacheDinamico = "cacheDinamico1"
var archivosEstaticos = [
	"/css/menu.css", "/MiProgressApp.styles.css", "/lib/jquery/dist/jquery.min.js",
	"/lib/bootstrap/dist/js/bootstrap.bundle.min.js", "/js/menu.js", "/", "/js/generic.js", "/img/loading.gif",
	"/Persona/listarPersonas"
]

self.addEventListener("install", event => {

	console.log("Evento Install")
	event.waitUntil(
		caches.open(nombreCacheEstatico).then(cache => {
			return cache.addAll(archivosEstaticos)
		})
	)


})

self.addEventListener("activate", event => {

	console.log("Evento Activate")
	event.waitUntil(self.clients.claim())
})

self.addEventListener("fetch", event => {

	const respuesta = caches.match(event.request).then(res => {

		if (res) return res;
		else {
			return fetch(event.request).then(response => {
				caches.open(nombreCacheDinamico).then(cache => {
					cache.put(event.request, response)
				})
				return response.clone();
			})
		}

	}).catch(err => {
		var response = new Response('<h1 class="text-danger">Para realizar esta accion necesita internet</h1>', {
			headers: {
				"Content-Type": "text/html"
			}
		})
		return response;
	})
	//if (event.request.url == "https://localhost:7283/css/menu.css") {
	//	event.respondWith(null);
	//}else
	//console.log(event.request.url)
	event.respondWith(respuesta)
})



