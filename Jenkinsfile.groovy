node {

    checkout scm

    docker.withRegistry('https://registry.hub.docker.com', 'dockerHub') {        
        
        def customImage = docker.build("ayuzzz1995/usermanagement-query", "-f usermanagementquery/Dockerfile .")

        /* Push the container to the custom Registry */
        customImage.push()       
        
    }
}
