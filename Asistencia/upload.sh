#\!/bin/bash
# Script para restaurar la base de datos MySQL en Docker
# Uso: bash upload.sh [archivo.sql]
#      Si no se indica archivo, usa el respaldo mas reciente de ./backups/

MYSQL_CONTAINER="mysql_asistencia"
DB_NAME="asistencia_db"
DB_ROOT_PASS="safe"
LOCAL_BACKUP_DIR="./backups"

echo "=== Restauracion de Base de Datos ==="
echo "Fecha: $(date '+%Y-%m-%d %H:%M:%S')"
echo ""

if [ -n "$1" ]; then
  BACKUP_FILE="$1"
else
  BACKUP_FILE=$(ls -t "$LOCAL_BACKUP_DIR"/*.sql 2>/dev/null | head -1)
  if [ -z "$BACKUP_FILE" ]; then
    echo "ERROR: No se encontro ningun archivo .sql en $LOCAL_BACKUP_DIR"
    echo "Uso: bash upload.sh <archivo.sql>"
    exit 1
  fi
  echo "Usando el respaldo mas reciente: $BACKUP_FILE"
fi

if [ \! -f "$BACKUP_FILE" ]; then
  echo "ERROR: El archivo '$BACKUP_FILE' no existe"
  exit 1
fi

if \! docker ps --format '{{.Names}}' | grep -q "^${MYSQL_CONTAINER}$"; then
  echo "ERROR: El contenedor '$MYSQL_CONTAINER' no esta corriendo"
  echo "Levantalo con: docker compose up -d"
  exit 1
fi

echo "[1/1] Restaurando '$BACKUP_FILE' en el contenedor '$MYSQL_CONTAINER'..."
docker exec -i "$MYSQL_CONTAINER" mysql -u root -p"$DB_ROOT_PASS" "$DB_NAME" < "$BACKUP_FILE"

if [ $? -ne 0 ]; then
  echo "ERROR: Fallo la restauracion de la base de datos"
  exit 1
fi

echo ""
echo "=== Restauracion completada ==="
echo "Base de datos '$DB_NAME' restaurada desde: $BACKUP_FILE"