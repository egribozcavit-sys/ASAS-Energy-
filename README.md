# ASAS-Energy-
Solar Energy &amp; Smart Energy Management System 
⚡ A.S.A.S. Energy
🌞 Solar Energy & Smart Energy Management System
🏢 Enterprise-Grade Energy Monitoring, Waste Detection & Optimization Platform
---
📊 Overview
A.S.A.S. Energy is a comprehensive solar energy monitoring and smart energy management system. It tracks solar panel production, battery storage, and home energy consumption in real-time. The system detects energy waste (idle devices, standby power, inefficient appliances) and provides intelligent recommendations to reduce costs.
Key capabilities:
🌞 Solar production monitoring
⚡ Device-level consumption tracking
🚫 AI-powered waste detection
🔋 Battery charge/discharge optimization
📱 Real-time SMS/email alerts
---
🏗️ Architecture
Built with 7-Layer Enterprise Architecture using .NET 8:
🔹 Domain Layer - Core business entities (SolarPanel, Inverter, Battery, EnergyMeter, Device, WasteAlert)
🔹 Application Layer - Business logic with CQRS and MediatR
🔹 Infrastructure Layer - IoT services (MQTT, Modbus), Weather API, Alerts
🔹 Persistence Layer - PostgreSQL, InfluxDB (time-series)
🔹 API Layer - RESTful endpoints, SignalR (real-time)
🔹 Web Layer - React dashboard, charts, analytics
🔹 Shared Layer - Common utilities, exceptions
---
🎯 Key Features
🌞 Solar Energy Monitoring
•	Real-time solar panel output tracking
•	Inverter status & efficiency monitoring
•	Battery level management
•	Grid integration & net metering
•	Weather-based production forecasting
⚡ Smart Energy Management
•	Device-level consumption monitoring
•	Real-time & historical analytics
•	Automatic load balancing
•	Peak hour alerts
•	Real-time cost calculation
🚫 Waste Detection
•	Idle device detection
•	Standby power alerts
•	Inefficient appliance identification
•	Solar curtailment detection
•	AI-powered anomaly detection
💡 Optimization
•	Personalized energy-saving tips
•	Automatic device control (smart relays)
•	Time-of-use optimization
•	Solar self-consumption maximization
•	Battery scheduling
📱 Alerts & Notifications
•	High consumption alerts (SMS/Email)
•	System fault notifications
•	Cost threshold warnings
•	Daily/weekly optimization tips
•	Grid outage notifications
---
🛠️ Tech Stack
🖥️ Backend:
•	.NET 8, ASP.NET Core
•	Entity Framework Core
•	PostgreSQL, InfluxDB, Redis
•	MediatR, FluentValidation
🔌 IoT:
•	MQTT, Modbus
•	ESP32/ESP8266
•	Shelly Relays
•	SCT-013, PZEM-004T sensors
🌐 Frontend:
•	React.js, TypeScript
•	TailwindCSS
•	Chart.js/Recharts
•	SignalR (real-time)
☁️ Cloud:
•	Azure IoT Hub, Azure Functions
•	Azure Time-Series Insights
•	SendGrid, Twilio
•	Docker, GitHub Actions
---
🚀 Getting Started
📋 Prerequisites:
•	.NET 8 SDK
•	Node.js 18+
•	PostgreSQL 15+
•	InfluxDB 2+
•	Redis 7+
⚡ Quick Start:
1.	Clone: git clone https://github.com/egribozcavit-sys/ASAS-Energy.git
2.	Restore: cd ASAS-Energy && dotnet restore
3.	Build: dotnet build
4.	Run: dotnet run –project src/API
🌐 Access:
•	API: http://localhost:5000
•	Swagger: http://localhost:5000/swagger
•	Dashboard: http://localhost:3000
---
📄 License
MIT License
---
👨‍💻 Author
Cavit Egriboz
16 years old, Enterprise Software Engineer
---