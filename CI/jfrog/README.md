# PRE REQUISITES

JFrog platform enabling Artifactory, Xray, Pipelines

| Service | Type | Name | Description | 
| ----------- | ----------- |----------- | ----------- |
| Artifactory | Nuget virtual repo | dark-nuget | aggregate nuget dev local and remote | 
| Artifactory | Nuget local repo   | dark-dev-nuget-local | | 
| Artifactory | Nuget local repo   | dark-rc-nuget-local | for nuget promotion | 
| Artifactory | Nuget remote repo  | dark-nugetorg-remote | | 
| Artifactory | Docker local repo   | dark-dev-docker-local | | 
| Artifactory | Docker local repo   | dark-rc-docker-local | for docker promotion | 
| Artifactory | Docker remote repo  | dark-dockerhub-remote | | 
| Artifactory | Generic local repo   | dark-dev-generic-local | | 
| Artifactory | Generic local repo   | dark-rc-generic-local | for  promotion | 
| Pipelines   | Github Integration | yann_github | pointing to https://github.com/cyan21 |
| Pipelines   | Artifactory Integration | artifactory_eu | |

## Repository creation

````
curl -uadmin:chaysinh -X PATCH "http://localhost:8081/artifactory/api/system/configuration" -H "Content-Type: application/yaml" -T repo.yml
````

if you change the repo names, make sure to edit : 
* repo name in the pipelines.steps.yaml (pipeline variables)


## Integration creation

integrations have to be created manually for now JFrog pipelines

if you change the integration name, make sure to update "--server-id-resolve" parameter in the build_app_dotnet step (the pipeline.step.yaml)

````
- jfrog rt dotnetc --server-id-resolve artifactory_eu --repo-resolve ${nugetRepo}
````


## Generate a custom runtime image

````
docker build -t dark-docker.artifactory-eu.soleng-emea.jfrog.team/dotnet/core/sdk:3.1-jfrog CI/jfrog/

docker login dark-docker.artifactory-eu.soleng-emea.jfrog.team

docker push dark-docker.artifactory-eu.soleng-emea.jfrog.team/dotnet/core/sdk:3.1-jfrog 
````


