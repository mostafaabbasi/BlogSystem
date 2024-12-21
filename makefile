.PHONY: up clean build

# Remove the old Docker image
clean:
	docker rmi -f blogsystem-api:latest || true

# Build a new Docker image
build: clean
	docker-compose build --no-cache

# Start services with docker-compose
up: build
	docker-compose up --force-recreate
