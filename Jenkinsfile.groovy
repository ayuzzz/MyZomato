node {

    checkout scm

    docker.withRegistry('https://registry.hub.docker.com', 'dockerHub') {        
        
        def customImage = docker.build("usermanagement-query", "-f usermanagementquery/Dockerfile .")

        /* Push the container to the custom Registry */
        customImage.push()       
        
    }
}
