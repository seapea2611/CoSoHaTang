# Stage 1: Build the Angular app
FROM node:14 as build

# Set working directory
WORKDIR /app

# Copy package.json and package-lock.json for dependency installation
COPY package.json yarn.lock ./

# Install dependencies
RUN yarn install --frozen-lockfile

# Copy the rest of the application files
COPY . .

# Build the Angular app in production mode
RUN yarn run build --prod

# Stage 2: Serve the app with NGINX
FROM nginx:stable-alpine

# Copy the built Angular app to NGINX's HTML directory
COPY --from=build /app/dist/* /usr/share/nginx/html/

# Copy a custom NGINX configuration file (optional)
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80 for the HTTP server
EXPOSE 80

# Start NGINX
CMD ["nginx", "-g", "daemon off;"]
