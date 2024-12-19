# Use an official Node.js image as a base for building the Angular app
FROM node:14 AS build

# Set the working directory inside the container
WORKDIR /app

# Install global dependencies: yarn (no need for gulp globally)
RUN rm -f /usr/local/bin/yarn /usr/local/bin/yarnpkg && npm install -g yarn

# Copy package files to install dependencies
COPY ./package.json ./yarn.lock ./

# Install project dependencies using yarn
RUN yarn

# Copy the rest of the application files to the container
COPY . .

# Copy appconfig.docker.json over appconfig.json
RUN mv ./src/assets/appconfig.docker.json ./src/assets/appconfig.json
RUN mv ./src/assets/appconfig.docker.json ./src/assets/appconfig.production.json
RUN mv ./package.docker.json ./package.json
RUN mv ./src/AppPreBootstrap.docker.ts ./src/AppPreBootstrap.ts

# Build the Angular application for production
RUN yarn run build:prod

# Use a lightweight Nginx image to serve the production build
FROM nginx:alpine

# Copy the built Angular application from the build stage
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
