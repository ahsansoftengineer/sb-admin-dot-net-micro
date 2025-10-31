#!/bin/bash
set -e

echo "🔐 Checking for dev-root-cert.crt..."
if [ -f /app/dev-root-cert.crt ]; then
    echo "✅ Found root cert, trusting..."
    
    # Ensure CA directory exists
    mkdir -p /usr/local/share/ca-certificates
    
    # Copy and normalize extension
    cp /app/dev-root-cert.crt /usr/local/share/ca-certificates/dev-root-cert.crt

    # Debian/Ubuntu or Alpine path
    if command -v update-ca-certificates &> /dev/null; then
        update-ca-certificates --fresh || true
    elif command -v update-ca-trust &> /dev/null; then
        update-ca-trust extract || true
    fi

    echo "🔒 Trusted custom CA successfully"
else
    echo "⚠️ No root cert found, proceeding without trusting custom CA"
fi

echo "🚀 Starting SBA.Hierarchy..."
exec dotnet SBA.Hierarchy.dll
