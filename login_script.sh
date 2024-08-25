#!/bin/bash

# Переменные
SUBSCRIPTION_ID="dbd355cc-0d75-429a-83d3-d6011ba640bf"
TENANT_ID="b9528b34-7933-4e6f-9ac9-f4aaed188725"
USER_EMAIL="tlnctrade@gmail.com"

# Логин в Azure
az login --scope https://management.core.windows.net//.default

# Установить подписку по умолчанию
az account set --subscription $SUBSCRIPTION_ID

# Показать информацию об учетной записи
az account show --output json

echo "Login and subscription settings applied successfully."
