FROM node:10.16.3
EXPOSE 3000
WORKDIR /app
COPY ["package.json", "package-lock.json*", "./"]
RUN npm install --silent
COPY . .
CMD ["npm", "start"]