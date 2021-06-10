ARG REPO=mcr.microsoft.com/dotnet/runtime-deps
FROM $REPO:5.0-alpine3.13-amd64

# Install .NET
# https://dotnet.microsoft.com/download/dotnet/3.1
RUN curl - dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/b6d4d475-d514-4a4b-8162-54f712077a3e/ea8849187e7bfec582b422082771cad0/aspnetcore-runtime-3.1.16-linux-musl-x64.tar.gz \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf dotnet.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    && rm dotnet.tar.gz

RUN mkdir webapi
COPY out/ webapi/

EXPOSE 80

CMD ["dotnet", "webapi/MyWebAPI.dll"]

