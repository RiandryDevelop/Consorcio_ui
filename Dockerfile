# Step 1: Use Node.js image to build the Angular app
FROM node:16 AS build

# Set the working directory
WORKDIR /app

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the Angular project files to the container
COPY . .

# Build the Angular app for production
RUN npm run build -- --output-path=dist --configuration=production

# Step 2: Use Nginx to serve the Angular app
FROM nginx:alpine

# Copy built Angular app to Nginx's default public directory
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
