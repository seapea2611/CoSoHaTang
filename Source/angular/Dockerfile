# Use an official Node.js image as a base
FROM node:14

# Set the working directory inside the container
WORKDIR /app

# Install global dependencies: yarn and gulp
RUN rm -f /usr/local/bin/yarn /usr/local/bin/yarnpkg && npm install -g yarn gulp

# Copy package files to install dependencies
COPY ./package.json ./yarn.lock ./

# Install project dependencies using yarn
RUN yarn

# Copy the rest of the application files to the container
COPY . .

# Rename gulpfile_dun.js to gulpfile.js temporarily for the build
RUN mv gulpfile_dun.js gulpfile.js

# Build the Angular application using gulp
RUN gulp build

# Use Nginx to serve the built Angular application
FROM nginx:alpine
COPY --from=0 /app/dist /usr/share/nginx/html

# Expose the port Angular will use
EXPOSE 80
EXPOSE 4200

# Start nginx
CMD ["nginx", "-g", "daemon off;"]
