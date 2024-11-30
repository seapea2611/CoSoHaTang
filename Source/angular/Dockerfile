# Use Node.js as the base image for building the app
FROM node:14 AS build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json for dependency installation
COPY package.json yarn.lock ./

# Install dependencies
RUN yarn install --frozen-lockfile

# Copy the entire Angular project into the container
COPY . .

# Build the Angular app for production
RUN yarn run publish

# Use Nginx as the base image for serving the app
FROM nginx:alpine AS production

# Copy built Angular app from the build stage
COPY --from=build /app/dist /usr/share/nginx/html

# Copy Nginx configuration (optional)
# COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose the port Nginx will use
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
