# PRE REQUISITES

JFrog platform enabling Artifactory, Xray, Pipelines

| Service | Type | Name | Description | 
| ----------- | ----------- |----------- | ----------- |
| Artifactory | Nuget virtual repo   | urs-dotnet | aggregate dotnet dev local and remote | 
| Artifactory | Nuget local repo     | urs-dotnet-dev-local | | 
| Artifactory | Nuget local repo     | urs-dotnet-rc-local | for dotnet promotion | 
| Artifactory | Nuget local repo     | urs-dotnet-release-local | for dotnet promotion | 
| Artifactory | Nuget remote repo    | urs-nugetorg-remote | | 
| Artifactory | Docker local repo    | urs-docker-dev-local | | 
| Artifactory | Docker local repo    | urs-docker-rc-local | | 
| Artifactory | Docker local repo    | urs-docker-release-local | | 
| Artifactory | Docker remote repo   | urs-dockerhub-remote | | 
| Artifactory | Generic local repo   | urs-generic-dev-local | | 
| Artifactory | Generic local repo   | urs-generic-rc-local | for  promotion | 
| Artifactory | Generic local repo   | urs-generic-release-local | for  promotion | 
| Pipelines   | Github Integration      | yann_github | pointing to https://github.com/cyan21 |
| Pipelines   | Artifactory Integration | artifactory_eu | |
| Pipelines   | Docker Integration      | urs_docker_registry | |

## Repository creation

````
curl -uadmin:chaysinh -X PATCH "http://localhost:8081/artifactory/api/system/configuration" -H "Content-Type: application/yaml" -T repo.yaml
````

if you change the repo names, make sure to edit : 
* repo name in the pipelines.steps.yaml (pipeline variables)


## Integration creation

integrations have to be created manually for now JFrog pipelines

if you change the integration name, make sure to update "--server-id-resolve" parameter in the build_app_dotnet step (the pipeline.step.yaml)

````
- jfrog rt dotnetc --server-id-resolve artifactory_eu --repo-resolve ${dotnetRepo}
````
> TO MAKE THE DEPENDENCY RESOLUTION, YOU MAY HAVE TO DISABLE THE "FORCE AUTHENTICATION" ON  THE REMOTE

## Generate a custom runtime image

````
docker build -t urs-docker.artifactory-eu.soleng-emea.jfrog.team/dotnet/core/sdk:3.1-jfrog CI/jfrog/

docker login urs-docker.artifactory-eu.soleng-emea.jfrog.team

docker push urs-docker.artifactory-eu.soleng-emea.jfrog.team/dotnet/core/sdk:3.1-jfrog 
````


