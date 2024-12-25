# Stage 1: Build the Angular App
FROM node:14 AS build

WORKDIR /app

COPY ./package.json ./yarn.lock ./
RUN rm -f /usr/local/bin/yarn /usr/local/bin/yarnpkg && npm install -g yarn gulp
RUN yarn

COPY . .
COPY ./src/assets/appconfig.docker.json ./src/assets/appconfig.production.json

# Build the Angular application for production
RUN yarn run ng build --configuration production

# Stage 2: Serve the app with Nginx
FROM nginx:alpine

# Copy the built Angular app from the "build" stage
COPY --from=build /app/dist /usr/share/nginx/html

# Copy a custom Nginx configuration (optional, see below)
# COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80 (default for HTTP)
EXPOSE 80

# Nginx will start automatically when the container runs
