node {

    checkout scm

    stage('Create docker images'){

        docker.withRegistry('https://registry.hub.docker.com', 'dockerHub') {        
            /*Build images*/
            def usermanagementQueryImage = docker.build("ayuzzz1995/myzomato-usermanagement-query", "-f usermanagementquery/Dockerfile .")
            def restaurantsQueryImage = docker.build("ayuzzz1995/myzomato-restaurants-query", "-f restaurantsquery/Dockerfile .")
            def productQueryImage = docker.build("ayuzzz1995/myzomato-product-query", "-f productquery/Dockerfile .")
            def ordersCommandImage = docker.build("ayuzzz1995/myzomato-orders-command", "-f orderscommand/Dockerfile .")
            def orderpaymentprocessingCommandImage = docker.build("ayuzzz1995/myzomato-orderpaymentprocessing-command", "-f orderPaymentProcessingCommand/Dockerfile .")

            /* Push the container to the custom Registry */
            usermanagementQueryImage.push()       
            restaurantsQueryImage.push()
            productQueryImage.push()
            customImordersCommandImageage.push()
            orderpaymentprocessingCommandImage.push()
        }
    }

    stage('Run containers'){
        bat "docker run -dp 44349:80 ayuzzz1995/myzomato-usermanagement-query"
        bat "docker run -dp 44339:80 ayuzzz1995/myzomato-restaurants-query"
        bat "docker run -dp 44310:80 ayuzzz1995/myzomato-product-query"
        bat "docker run -dp 44337:80 ayuzzz1995/myzomato-orders-command"
        bat "docker run -dp 44364:80 ayuzzz1995/myzomato-orderpaymentprocessing-command"
    }
}
