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

# Copy appconfig.docker.json over appconfig.json
COPY ./src/assets/appconfig.docker.json ./src/assets/appconfig.json

# Expose the port Angular will use
EXPOSE 4200

# Start the Angular development server
CMD ["yarn", "run", "start"]
