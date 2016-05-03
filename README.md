# 소개
인스톨쉴드 ISM 파일 에디터입니다.
커맨드라인으로 지정된 ism 파일의 product code, product version, package code를 수정 하실 수 있습니다.

# 사용법
ismeditor.exe로 실행 하실 수 있으며, 파라미터는 다음의 사용법을 참조 하여 사용하시면 됩니다.
![1](https://cloud.githubusercontent.com/assets/3689439/14973581/8d7661d2-1124-11e6-9c45-6b1fb0c73c43.png)

# 활용 
TeamCity나 Jenkins를 이용한 자동 빌드 시스템으로 지속적인 통합 구현 시 빌드마다 새로운 버전의 인스톨쉴드 패키지를 생성 하실 수 있습니다.
다음은 TeamCity의 빌드 스크립트 예제 입니다.
![2](https://cloud.githubusercontent.com/assets/3689439/14973601/c73cd3ec-1124-11e6-871b-ea678dedebca.png)

- "C:\Util\ISMEditor\ISMEditor.exe" -p %teamcity.build.workingDir%\SightPro.Deploy.ism -v 2.1.%build.counter%.0
