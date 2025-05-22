# Online Store Management System

## Building the Installer

### Prerequisites
1. [Inno Setup Compiler](https://jrsoftware.org/isdl.php) (version 6.0 or later)
2. [MySQL Installer](https://dev.mysql.com/downloads/installer/) (version 8.0.42.0)

### Steps to Build the Installer

1. **Download Required Files**
   - Download MySQL Installer (version 8.0.42.0) from the [MySQL website](https://dev.mysql.com/downloads/installer/)
   - Place the downloaded `mysql-installer-community-8.0.42.0.msi` in the same directory as `setup.iss`

2. **Build the Installer**
   - Open `setup.iss` in Inno Setup Compiler
   - Click the "Compile" button (or press Ctrl+F9)
   - The installer will be generated as `OnlineStoreManagement_Installer.exe` in the same directory

### What's Included in the Installer
- Online Store Management System application
- MySQL Server 8.0
- Database initialization scripts
- All required dependencies and resources

### Installation Process
1. Run `OnlineStoreManagement_Installer.exe`
2. Follow the installation wizard
3. The installer will:
   - Install MySQL Server 8.0
   - Create and configure the database
   - Install the application and its dependencies
   - Create desktop shortcuts

### Troubleshooting
If you encounter any issues during installation:
1. Ensure you have administrator privileges
2. Check that no other MySQL instances are running
3. Verify that ports 3306 (MySQL) are not in use
4. Check the Windows Event Viewer for any error messages

## Development
- The installer configuration is in `setup.iss`
- Database setup scripts are in `init_db.sql` and `OnlineStoreDB.sql`
- MySQL configuration is handled by `setup_mysql.bat`

## File Structure
```
├── setup.iss                    # Inno Setup script
├── setup_mysql.bat             # MySQL setup script
├── init_db.sql                 # Database initialization
├── OnlineStoreDB.sql           # Database schema and data
├── OnlineStoreManagement.exe   # Main application
└── [Other application files]   # Dependencies and resources
``` 