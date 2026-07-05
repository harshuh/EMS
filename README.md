# EMS

EMS is a simple Employee Management System API built with ASP.NET Core 8. It provides RESTful endpoints for performing CRUD (Create, Read, Update, Delete) operations on employee data. The application uses Entity Framework Core to interact with a SQL Server database.

## Features

- Get a list of all employees.
- Add a new employee to the system.
- Retrieve a specific employee's details by their ID.
- Update an existing employee's information.
- Delete an employee from the system.

## Technologies Used

-   **.NET 8**
-   **ASP.NET Core Web API**
-   **Entity Framework Core 8**
-   **SQL Server**
-   **Swagger (Swashbuckle)** for API documentation and testing.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (e.g., Express or Developer edition)
-   A code editor like [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Setup

1.  **Clone the repository:**
    ```sh
    git clone https://github.com/harshuh/EMS.git
    cd EMS
    ```

2.  **Configure the database connection:**
    -   Open the `appsettings.json` file.
    -   Modify the `DefaultConnetion` string to point to your local SQL Server instance. For example, if your server name is `.` (for LocalDB) or `SQLEXPRESS`, update it accordingly.

    ```json
    "ConnectionStrings": {
        "DefaultConnetion": "Server=YOUR_SERVER_NAME;Database=EMS_DB;Trusted_Connection=true;TrustServerCertificate=true;"
    }
    ```

3.  **Apply database migrations:**
    -   Open a terminal in the project's root directory.
    -   Run the following command to create the database and apply the table schema.
    ```sh
    dotnet ef database update
    ```

4.  **Run the application:**
    ```sh
    dotnet run
    ```
    The API will be running on `http://localhost:5071` (or another port specified in `Properties/launchSettings.json`).

5.  **Access the API documentation:**
    -   Open your web browser and navigate to `http://localhost:5071/swagger`.
    -   You can use the Swagger UI to explore and test all the available API endpoints.

## API Endpoints

The base URL for all endpoints is `/api/Employee`.

### Get All Employees

-   **Endpoint:** `GET /api/Employee`
-   **Description:** Retrieves a list of all employees.
-   **Success Response:** `200 OK`
    ```json
    [
      {
        "id": "c1f7b7e8-1c4b-4b1e-8a1a-3e5f2a1b7e9a",
        "employeeId": 101,
        "role": "Software Engineer",
        "name": "John Doe",
        "email": "john.doe@example.com",
        "phone": 1234567890,
        "salary": 80000.00
      }
    ]
    ```

### Add a New Employee

-   **Endpoint:** `POST /api/Employee`
-   **Description:** Creates a new employee record.
-   **Request Body:**
    ```json
    {
      "employeeId": 102,
      "role": "Project Manager",
      "name": "Jane Smith",
      "email": "jane.smith@example.com",
      "phone": 9876543210,
      "salary": 95000.00
    }
    ```
-   **Success Response:** `201 Created` with the newly created employee object.
-   **Error Response:** `409 Conflict` if an employee with the same `EmployeeId` already exists.

### Get Employee by ID

-   **Endpoint:** `GET /api/Employee/{employeeId}`
-   **Description:** Retrieves a single employee by their `employeeId`.
-   **Example URL:** `/api/Employee/101`
-   **Success Response:** `200 OK`
-   **Error Response:** `404 Not Found` if no employee with the specified ID is found.

### Update an Employee

-   **Endpoint:** `PUT /api/Employee/{employeeId}`
-   **Description:** Updates the details of an existing employee.
-   **Example URL:** `/api/Employee/101`
-   **Request Body:**
    ```json
    {
      "employeeId": 101,
      "role": "Senior Software Engineer",
      "name": "Johnathan Doe",
      "email": "john.doe.updated@example.com",
      "phone": 1234567891,
      "salary": 85000.00
    }
    ```
-   **Success Response:** `200 OK` with the updated employee object.
-   **Error Response:** `404 Not Found` if the employee to be updated does not exist.

### Delete an Employee

-   **Endpoint:** `DELETE /api/Employee/{employeeId}`
-   **Description:** Deletes an employee from the system.
-   **Example URL:** `/api/Employee/101`
-   **Success Response:** `204 No Content`
-   **Error Response:** `404 Not Found` if the employee to be deleted does not exist.