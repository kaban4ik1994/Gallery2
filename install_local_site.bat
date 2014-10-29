cd /D C:\Windows\System32\inetsrv

appcmd.exe add apppool /name:gallery.dev  /managedRuntimeVersion:v4.0 /managedPipelineMode:Integrated

appcmd.exe add site /name:gallery.dev /bindings:http/*:80:gallery.dev /physicalPath:%~dp0WebSite\Gallery.WebUI\
appcmd.exe set site /site.name:gallery.dev /[path='/'].applicationPool:gallery.dev